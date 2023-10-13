clc
clear all
X1 = 0.07; %
Y1 = 0.03; %
Z1 = -0.0375; % - GREEN
% Z1 = 0.118; % - RED
% Z1 = 0.039; % - BLUE
Tx = transl(X1, Y1, Z1);
T= trotx(180,'deg');