
function grabSend(arduino,data)


%数据传输模块

writeline(arduino,data);%将数据以文本形式写入文件。

disp(data);


%clear all; clc; close all;
end