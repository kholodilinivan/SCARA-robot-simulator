
%arduino=serialport("COM9",115200);%只需要运行1次


%数据传输模块
dataz="z6000";
datay="y-824";
datax="x5000";
writeline(arduino,dataz);pause(2);%将数据以文本形式写入文件。
writeline(arduino,datay);pause(2);
writeline(arduino,datax);pause(2);
c="m";
writeline(arduino,c);pause(2);
color = readline(arduino);
color = str2double(color);
pause(2);
%color2 = fgetl(arduino);


data = "a"; % 要发送的指令
%str = num2str(data); % 将double型数字转换为字符串格式
writeline(arduino,data);%将数据以文本形式写入文件。
pause(7);

data = "b"; % 要发送的指令
%str = num2str(data); % 将double型数字转换为字符串格式
writeline(arduino,data);%将数据以文本形式写入文件。
pause(8);

data = "c"; % 要发送的指令
%str = num2str(data); % 将double型数字转换为字符串格式
writeline(arduino,data);%将数据以文本形式写入文件。
pause(3);

data = "d"; % 要发送的指令
%str = num2str(data); % 将double型数字转换为字符串格式
writeline(arduino,data);%将数据以文本形式写入文件。
pause(8);

data = "e"; % 要发送的指令
%str = num2str(data); % 将double型数字转换为字符串格式
writeline(arduino,data);%将数据以文本形式写入文件。
pause(6);

data = "f"; % 要发送的指令
%str = num2str(data); % 将double型数字转换为字符串格式
writeline(arduino,data);%将数据以文本形式写入文件。
pause(3);

data = "a"; % 要发送的指令
str = num2str(data); % 将double型数字转换为字符串格式
writeline(arduino,data);%将数据以文本形式写入文件。
pause(3);
%clear all; clc; close all;