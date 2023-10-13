%a = arduino();
%arduino=serialport("COM9",115200);%只需要运行1次
%arduino = serial('COM7', 'BaudRate', 9600);  % 连接到Arduino的端口和波特率

data = "a"; % 要发送的指令
%str = num2str(data); % 将double型数字转换为字符串格式
writeline(arduino,data);%将数据以文本形式写入文件。
pause(1);

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