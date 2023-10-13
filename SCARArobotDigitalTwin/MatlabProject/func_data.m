function func_data(ClientHandle, Q, b )
% writeTCP(ClientHandle,sprintf("ModRobot:%f,%f,%f,%f",Q(b,1),Q(b,2)*180/pi,Q(b,3)*180/pi,(Q(b,4)-pi/4)*180/pi));
writeTCP(ClientHandle,sprintf("ModRobot:%f,%f,%f,%f,d%",(Q(b,1)*0.746-0.00047),Q(b,2)*180/pi,Q(b,3)*180/pi,45));%(Q(b,3)+Q(b,2))*180/pi));%Q(b,4)*180/pi));%
%Q(b,1)经过改造，原为其本身
pause(0.054);%(Q(b,4)+9*pi/32)*180/pi
