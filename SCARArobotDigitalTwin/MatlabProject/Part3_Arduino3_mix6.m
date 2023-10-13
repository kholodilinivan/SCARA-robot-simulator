
%clc;

%close all;
name = "Matlab";
Client = TCPInit('127.0.0.1',55011,name);
%arduino=serialport("COM9",9600);%只需要运行1次，连接端口

%fig= capture_fig(Client);

%grabSend(arduino,"a");%手臂到达初始位置
%pause(3);

gripping_point = 0.056;

%gripping_point = 0.1978;

L(1) = Link([0 0 0.067 0 1]);  %定义连杆的D-H参数，关节角，连杆偏距，连杆长度，连杆转角
L(2) = Link([0 -0.017 0.092 0 0]);
L(3) = Link([0 -0.01 0.095 0 0]);
L(4) = Link([0 -0.04 0 0 0]);
L(5) = Link([0 0 0 0 0]);
L(6) = Link([0 0 0 0 0]);

L(1).qlim = [0.01 0.12];              %关节角度限制
L(2).qlim = [-105 115]/180*pi;
L(3).qlim = [-75 205]/180*pi;
L(4).qlim = [0 180]/180*pi;

robot = SerialLink(L);              %连接连杆
joints = [0.12 0 0 0 0 0];            %指定的关节角





%robot.plot(joints);
%方块位置
%Grab = 2; % activate EE (0 - release the object, 1 - grab, 2 - do nothing)
t = 0:0.1:6;
X1 = 0.04;  % Z
Y1 = 0.135; % -X
Z1 = -0.005;  % Y - GREEN
% Z1 = 3.5/100; % - RED
% Z1 = 5.5/100; % - BLUE

T = transl(X1, Y1, Z1)* trotz(180);%根据给定终点，得到终点位姿
qi1 = robot.ikine(T,'mask',[1 1 1 1 0 0]);%根据终点点位姿，得到终点关节角
qf1 = [0.12 0 0 0 0 0];%机器人初始位置
q = jtraj(qf1,qi1,t);%五次多项式轨迹，得到关节角度，角速度，角加速度，50为采样点个数

%qq=q(61,3)-q(1,3);%需要旋转的角度
%robot.plot(q);
numberTran(arduino,q(61,1),q(61,2),q(61,3));%将计算结果转换为电机参数,并传入arduino
%robot.plot(q);传输到unity
b = 1;
for a = 1 : length(q)
    func_data(Client, q, b);
    b=b+1;     
end

pause(4);


% take object
grabSend(arduino,"c");

% take object
Grab = 1;
func_grab(Client, Grab);
func_data(Client,q,b-1);
pause(2);

%将方块移动到摄像头上
X3 = 0.03;  % Z
Y3 = -0.095; % -X
Z3 = 0.015;  % Y 
T3 = transl(X3, Y3, Z3)* trotz(180);%根据给定终点，得到终点位姿
qf3 = robot.ikine(T3,'mask',[1 1 1 1 0 0]);
q = jtraj(qi1,qf3,t);


 %robot.plot(q);
numberTran(arduino,q(61,1),q(61,2),q(61,3));%将计算结果转换为电机参数,并传入arduino
 %robot.plot(q);传输到unity中
b = 1;
for a = 1 : length(q)
    func_data(Client, q, b); 
    b=b+1;
end
pause(5);


%识别颜色
%加入一个grabSend(arduino,"h");delay(2);并在arduino中添加一个对应函数，让h命令颜色传感器工作
color1 = readline(arduino);%读取传输到的色彩信息
color1 = str2double(color1);
color = color_check(Client); % function for detecting colors
    
    if color == 1 % Red sorting
        X2 = 0.21;  % Z
        Y2 = -0.08; % -X
        Z2 = -0.005;  % Y
    elseif color == 2 % Green sorting
        X2 = 0.21;  % Z
        Y2 = 0.07; % -X
        Z2 = -0.005;  % Y
    else % Blue sorting
        X2 = 0.21; % Z
        Y2 = 0.001; % -X
        Z2 =-0.005; % Y   
    end
    
    pause(1);

%机械手臂将蓝色方块放到指定位置
%起点不变，
%X2 = 8.26/100;  % Z
%Y2 = 0.85/100; % -X
%Z2 = 1.51/100;  % Y - GREEN
T2 = transl(X2, Y2, Z2)* trotz(180);%根据给定终点，得到终点位姿
qi2 = robot.ikine(T2,'mask',[1 1 1 1 0 0]);%根据终点点位姿，
% 得到终点关节角.'mask' 参数是一个掩码向量，用于指定执行逆解运动学时要考虑的自由度。
% 在这里，[1 1 1 1 0 0] 表示机器人的前四个自由度（平移方向）是可用的，后两个自由度（旋转方向）是被限制的。
%qf1 = [0.12 0 0 0 0 0];%机器人初始位置
q = jtraj(qf3,qi2,t);

%qq=q(61,3)-q(1,3);%需要旋转的角度
numberTran(arduino,q(61,1),q(61,2),q(61,3));%将计算结果转换为电机参数,并传入arduino
%robot.plot(q);传输到unity中
b = 1;
for a = 1 : length(q)
    func_data(Client, q, b); 
    b=b+1;
end

pause(4);



% release object
grabSend(arduino,"f");
% release object
grab = 0;
func_grab(Client, grab);
func_data(Client,q,b-1);

pause(2);

%back to initial pos
%grab = 2;

q = jtraj(qi2,qf1,t);
 %robot.plot(q);
%func_grab(Client, Grab);

%qq=q(61,3)-q(1,3);%需要旋转的角度
numberTran(arduino,q(61,1),q(61,2),q(61,3));%将计算结果转换为电机参数,并传入arduino
b = 1;
for a = 1 : length(q)
    func_data(Client, q, b); 
    b=b+1;
end

pause(5);


fprintf(1,"Disconnected from server\n");
