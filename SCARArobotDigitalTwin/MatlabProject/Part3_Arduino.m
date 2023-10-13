%% Pick up object (1st level)
%clc;

%close all;
name = "Matlab";
%arduino=serialport("COM9",115200);%只需要运行1次，连接端口

gripping_point = 0.056;

%gripping_point = 0.1978;

L(1) = Link([0 0 0.0263 0 1]);             %定义连杆的D-H参数，关节角，连杆偏距，连杆长度，连杆转角
L(2) = Link([0 -0.005 0.036 0 0]);
L(3) = Link([0 -0.031 0.0416 0 0]);
L(4) = Link([0 -0.0025 0 0 0]);
L(5) = Link([0 0 0 0 0]);
L(6) = Link([0 0 0 0 0]);

L(1).qlim = [0.04 0.09];              %关节角度限制
L(2).qlim = [-105 115]/180*pi;
L(3).qlim = [-75 205]/180*pi;
L(4).qlim = [0 180]/180*pi;

robot = SerialLink(L);              %连接连杆
joints = [0.09 0 0 0 0 0];            %指定的关节角
grabSend(arduino,"a");%手臂到达初始位置
pause(5);


%robot.plot(joints);

Grab = 2; % activate EE (0 - release the object, 1 - grab, 2 - do nothing)
t = [ 0:0.1:2];
X1 = 2.1/100;  % Z
Y1 = 5.28/100; % -X
Z1 = 0.5/100;  % Y - GREEN
% Z1 = 3.5/100; % - RED
% Z1 = 5.5/100; % - BLUE

T = transl(X1, Y1, Z1)* trotz(180);%根据给定终点，得到终点位姿
qi1 = robot.ikine(T,'mask',[1 1 1 1 0 0]);%根据终点点位姿，得到终点关节角
qf1 = [0.09 0 0 0 0 0];%机器人初始位置
q = jtraj(qf1,qi1,t);%五次多项式轨迹，得到关节角度，角速度，角加速度，50为采样点个数

%robot.plot(q);
numberTran(arduino,q(21,1),q(21,2),q(21,3));%将计算结果转换为电机参数,并传入arduino
pause(7);








% take object
grabSend(arduino,"c");
pause(3);

%将方块移动到摄像头上
X3 = 3.15/100;  % Z
Y3 = -4.07/100; % -X
Z3 = 2/100;  % Y 
T3 = transl(X3, Y3, Z3)* trotz(180);%根据给定终点，得到终点位姿
qf3 = robot.ikine(T3,'mask',[1 1 1 1 0 0]);
q = jtraj(qi1,qf3,t);

 %robot.plot(q);
numberTran(arduino,q(21,1),q(21,2),q(21,3));%将计算结果转换为电机参数,并传入arduino
pause(7);


%识别颜色
%color = color_check(Client); % function for detecting colors
    
    %if color == 1 % Red sorting
        %X2 = 8.26/100;  % Z
        %Y2 = -2.1/100; % -X
       % Z2 = 1/100;  % Y
    %elseif color == 2 % Green sorting
       % X2 = 8.26/100;  % Z
       % Y2 = 3.74/100; % -X
       % Z2 = 1/100;  % Y
    %else % Blue sorting
        X2 = 8.26/100;  % Z
        Y2 = 0.85/100; % -X
        Z2 = 1/100;  % Y   
   % end
    
    %pause(1);

%机械手臂将蓝色方块放到指定位置
%起点不变，
%X2 = 8.26/100;  % Z
%Y2 = 0.85/100; % -X
%Z2 = 1.51/100;  % Y - GREEN
T2 = transl(X2, Y2, Z2)* trotz(180);%根据给定终点，得到终点位姿
qi2 = robot.ikine(T2,'mask',[1 1 1 1 0 0]);%根据终点点位姿，
% 得到终点关节角.'mask' 参数是一个掩码向量，用于指定执行逆解运动学时要考虑的自由度。
% 在这里，[1 1 1 1 0 0] 表示机器人的前四个自由度（平移方向）是可用的，后两个自由度（旋转方向）是被限制的。
qf1 = [0.09 0 0 0 0 0];%机器人初始位置
q = jtraj(qf3,qi2,t);

numberTran(arduino,q(21,1),q(21,2),q(21,3));%将计算结果转换为电机参数,并传入arduino
pause(5);



% release object
grabSend(arduino,"f");
pause(2);

%back to initial pos
%grab = 2;
b = 1;
q = jtraj(qi2,qf1,t);
 %robot.plot(q);
%func_grab(Client, Grab);
numberTran(arduino,q(21,1),q(21,2),q(21,3));%将计算结果转换为电机参数,并传入arduino
pause(5);


fprintf(1,"Disconnected from server\n");
