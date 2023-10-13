L(1) = Link([0 0 0.1 pi/2 0]);%定义连杆的D-H参数，关节角，连杆偏距，连杆长度，连杆转角
L(2) = Link([pi/2 0 0.1 0 0]);
L(3) = Link([pi/2 0 0.1 0 0]);
L(4) = Link([0 0 0 0 0]);
L(5) = Link([0 0 0 0 0]);
L(6) = Link([0 0 0 0 0]);

%L(1).qlim = [0.04 0.099];%关节角度限制
L(2).qlim = [-105 115]/180*pi;
L(3).qlim = [-75 205]/180*pi;
L(4).qlim = [0 180]/180*pi;

robot = SerialLink(L);%连接连杆
joints = [20 30 30 0 0 0];%指定的关节角
robot.plot(joints);