function numberTran(arduino,numberz,numbery,numberx)

letter1 = 'z';
letter2 = 'y';
letter3 = 'x';
%需要计算将算的角度值变为电机的值
%y1=numbery;
numberz=numberz*205560-11667;%原为100000

numbery=numbery*945-1900;

numberx=0.8*numbery+3419.6+numberx*1455;%由于机械手臂问题，L3会有偏角

%numberx=(numberx+y1*0.517)*1455+2000;%由于机械手臂问题，L3会有偏角

% 合并并转换为字符型
combined1 = [letter1, num2str(numberz)];
combined2 = [letter2, num2str(numbery)];
combined3 = [letter3, num2str(numberx)];

writeline(arduino,combined1);pause(2);%将数据以文本形式写入文件。
writeline(arduino,combined2);pause(2);
writeline(arduino,combined3);pause(2);
c="m";
writeline(arduino,c);


% 显示结果
disp(combined1);
disp(combined2);
disp(combined3);
end
