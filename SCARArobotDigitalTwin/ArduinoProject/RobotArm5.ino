#include <Servo.h>
#include <AccelStepper.h> 
#include "GyverEncoder.h"
#include <EEPROM.h>
#define MOVE_SPEED 100 
#include <Arduino.h>
#include <Sentry.h>
#define SNAPSHOT_TO_SD_CARD false
#define SNAPSHOT_TO_UART false
#define SNAPSHOT_TO_USB true
#define SNAPSHOT_TO_WIFI false
#define SNAPSHOT_FROM_SCREEN false

//定义颜色
typedef Sentry2 Sentry;

#define SENTRY_I2C
// #define SENTRY_UART

#ifdef SENTRY_I2C
#include <Wire.h>
#endif
#ifdef SENTRY_UART
#include <SoftwareSerial.h>
#define TX_PIN 51
#define RX_PIN 49
SoftwareSerial mySerial(RX_PIN, TX_PIN);
#endif

#define VISION_TYPE Sentry::kVisionColor
Sentry sentry;

//定义电机
const int enablePin = 8;  // 使能控制引脚

const int xdirPin = 5;     // x方向控制引脚
const int xstepPin = 2;    // x步进控制引脚
const int ydirPin = 6;     // y方向控制引脚
const int ystepPin = 3;    // y步进控制引脚
const int zdirPin = 7;     // Z轴方向控制销，L1
const int zstepPin = 4;    // Z轴步进电机控制引脚，

const int xEndstopPin = 11;  // X轴限位开关销
const int yEndstopPin = 10; // 
const int zEndstopPin = 9; // 

//const int moveStepsZ = 200*8;    //测试电机运行使用的运行步数


Servo myServo1; //创建Servo对象
Servo myServo2; //创建Servo对象

AccelStepper stepper1(1,xstepPin,xdirPin);//建立步进电机对象1
AccelStepper stepper2(1,ystepPin,ydirPin);//建立步进电机对象2
AccelStepper stepper3(1,zstepPin,zdirPin);//创建步进电机3


int dataIndex=0; //存储输入数据序列号
int dataPoint1[5]={13000,-1900,1880,0,0};
int dataPoint2[5]={540,-1000,4980,-8,0};
int dataPoint3[5]={540,-1000,4980,-8,60};
int dataPoint4[5]={4580,-2720,-1635,-8,60};
int dataPoint5[5]={4425,-2540,3135,-8,60};
int dataPoint6[5]={4425,-2540,3135,-8,0};
//测试组
int dataPoint11[5]={0,0,0,0,0};

void setup() 
{
  //爪子电机设置
  myServo1.attach(A1);//A1为爪子转动；（A0为爪子抓放，0度为张开，90度为闭合）；
  myServo2.attach(A0);

//对步进电机设置
  
  pinMode(xstepPin,OUTPUT);     // Arduino控制A4988x步进引脚为输出模式
  pinMode(xdirPin,OUTPUT);      // Arduino控制A4988x方向引脚为输出模式
  pinMode(ystepPin,OUTPUT);     // Arduino控制A4988y步进引脚为输出模式
  pinMode(ydirPin,OUTPUT);      // Arduino控制A4988y方向引脚为输出模式
  pinMode(zstepPin,OUTPUT);     // Arduino控制A4988z步进引脚为输出模式
  pinMode(zdirPin,OUTPUT);      // Arduino控制A4988z方向引脚为输出模式
  
  pinMode(enablePin,OUTPUT);   // Arduino控制A4988使能引脚为输出模式
  digitalWrite(enablePin,LOW); // 将使能控制引脚设置为低电平从而让
  
  stepper1.setMaxSpeed(5000.0);     // 设置电机最大速度300 
  stepper1.setAcceleration(1500.0);  // 设置电机加速度20.0  
  stepper2.setMaxSpeed(5000.0);  // 设置电机最大速度300 
  stepper2.setAcceleration(1500.0);  // 设置电机加速度20.0 
  stepper3.setMaxSpeed(5000);       // Set the maximum speed in steps per second
  stepper3.setAcceleration(1500);    // Set the acceleration in steps per second per second
  //stepper3.setSpeed(500);           // Set the speed in steps per second
  //stepper3.setCurrentPosition(0);   // Set the current position of the stepper motor
  
  pinMode(xEndstopPin, INPUT_PULLUP);   // X轴限位开关引脚设置为上拉输入模式
  pinMode(yEndstopPin, INPUT_PULLUP);   //
  pinMode(zEndstopPin, INPUT_PULLUP); 


    //Serial.begin(9600);//启动串口通信
    // put your setup code here, to run once:
   // Serial.println("input data");
    
    //启动时位置归零，并设置统一的坐标系
    myServo2.write(0);
     manipZeroSetup(stepper1, stepper2, stepper3, xEndstopPin, yEndstopPin, zEndstopPin, MOVE_SPEED);

//定义颜色
sentry_err_t err = SENTRY_OK;

  Serial.begin(9600);

  //Serial.println("Waiting for sentry initialize...");
#ifdef SENTRY_I2C
  Wire.begin();
  while (SENTRY_OK != sentry.begin(&Wire)) { yield(); }
#endif  // SENTRY_I2C
#ifdef SENTRY_UART
  mySerial.begin(9600);
  while (SENTRY_OK != sentry.begin(&mySerial)) { yield(); }
#endif  // SENTRY_UART
  //Serial.println("Sentry begin Success.");
  int param_num = 1;       // 1~SENTRY_MAX_RESULT
  sentry.SetParamNum(VISION_TYPE, param_num);
  sentry_object_t param;
  for (size_t i = 1; i <= param_num; i++)
  {
    /* Set x/y/w/h */
    param.x_value = 105 * i / (param_num + 1);
    param.y_value = 55;
    param.width = i * 8 + 1;
    param.height = i * 8 + 1;
    err = sentry.SetParam(VISION_TYPE, &param, i);
    if (err) {
      //Serial.print("sentry.SetParam");
      //Serial.print(i);
      //Serial.print(" Error: 0x");
      //Serial.println(err, HEX);
      for (;;);
    }
  }
  err = sentry.VisionBegin(VISION_TYPE);
 // Serial.print("sentry.VisionBegin(kVisionColor) ");
  if (err) {
    //Serial.print("Error: 0x");
  } else {
    //Serial.print("Success: 0x");
  }
  //Serial.println(err, HEX);
}

void loop() 
{
  // put your main code here, to run repeatedly:
  if(Serial.available()>0)
{
  
  dataIndex++;
  //Serial.print("dataIndex=");
  //Serial.print(dataIndex);
  //Serial.print(" ,");

  char servoName=Serial.read();//获取电机指令中电机编号；
  //Serial.print("ServoName=");
  //Serial.print(servoName);
  //Serial.print(" ,");
  
      //连杆电机模块
      stepper3.runSpeed();                 // 控制步进电机持续以设置的速度运动
      int data=Serial.parseInt();

      switch(servoName)
      {

        //z,y,x为自主输入角度
        case'z':
         // Serial.print("Set servo position:");
         // Serial.println(data);
          dataPoint11[0]=data;
          
          break;

        case'x':
            //Serial.print("Set servo position:");
            //Serial.println(data);
            dataPoint11[2]=data;
            
            
            break;

        case'y':
            //Serial.print("Set servo position:");
            //Serial.println(data);
            dataPoint11[1]=data;
            
            break;

            //a-f为输入指令进行抓取
        case'a':
            stepper3.moveTo(dataPoint1[0]);
              //while (stepper3.distanceToGo() != 0)
            stepper2.moveTo(dataPoint1[1]);
             //while (stepper2.distanceToGo() != 0)           
            
            stepper1.moveTo(dataPoint1[2]);
              while (stepper1.distanceToGo() != 0||stepper2.distanceToGo() != 0||stepper3.distanceToGo() != 0)
            
                {
                  stepper3.run();
                  stepper2.run();
                  stepper1.run();
                  myServo1.write(dataPoint1[3]);
                  myServo2.write(dataPoint1[4]);
                  

                }
                //Serial.println(2);
              break;
          case'b':
            stepper3.moveTo(dataPoint2[0]);
              //while (stepper3.distanceToGo() != 0)
            stepper2.moveTo(dataPoint2[1]);
             //while (stepper2.distanceToGo() != 0)           
            
            stepper1.moveTo(dataPoint2[2]);
              while (stepper1.distanceToGo() != 0||stepper2.distanceToGo() != 0||stepper3.distanceToGo() != 0)
            
                {
                  stepper3.run();
                  stepper2.run();
                  stepper1.run();
                  myServo1.write(dataPoint2[3]);
                  myServo2.write(dataPoint2[4]);

                }
              break;
          case'c':
              
                  myServo1.write(dataPoint3[3]);
                  delay(100);
                  myServo2.write(dataPoint3[4]);

                
              break;

          case'd':
            stepper3.moveTo(dataPoint4[0]);
              //while (stepper3.distanceToGo() != 0)
            stepper2.moveTo(dataPoint4[1]);
             //while (stepper2.distanceToGo() != 0)           
            
            stepper1.moveTo(dataPoint4[2]);
              while (stepper1.distanceToGo() != 0||stepper2.distanceToGo() != 0||stepper3.distanceToGo() != 0)
            
                {
                  stepper3.run();
                  stepper2.run();
                  stepper1.run();
                  myServo1.write(dataPoint4[3]);
                  myServo2.write(dataPoint4[4]);

                }
              break;
          case'e':
            stepper3.moveTo(dataPoint5[0]);
              //while (stepper3.distanceToGo() != 0)
            stepper2.moveTo(dataPoint5[1]);
             //while (stepper2.distanceToGo() != 0)           
            
            stepper1.moveTo(dataPoint5[2]);
              while (stepper1.distanceToGo() != 0||stepper2.distanceToGo() != 0||stepper3.distanceToGo() != 0)
            
                {
                  stepper3.run();
                  stepper2.run();
                  stepper1.run();
                  myServo1.write(dataPoint5[3]);
                  myServo2.write(dataPoint5[4]);

                }
              break;
          case'f':
            
                  myServo1.write(dataPoint6[3]);
                  delay(100);
                  myServo2.write(dataPoint6[4]);

                
              break;
        case'm':
              stepper3.moveTo(dataPoint11[0]);
              stepper1.moveTo(dataPoint11[2]);
              stepper2.moveTo(dataPoint11[1]);
            
            while (stepper1.distanceToGo() != 0||stepper2.distanceToGo() != 0||stepper3.distanceToGo() != 0)
            
                {
                  
                  stepper3.run();
                  stepper2.run();
                  stepper1.run();
                  

                }
                //Serial.println(1);
            break;


        case'g':
            //颜色检测
              int obj_num = sentry.GetValue(VISION_TYPE, kStatus);
                if (obj_num) 
                {
                  //Serial.print("Totally ");
                  //Serial.print(obj_num);
                  //Serial.println(" objects");
                  
                  for (int i = 1; i <= obj_num; ++i) {
                    int l = sentry.GetValue(VISION_TYPE, kLabel, i);
                    //Serial.print('|');
                    Serial.println(l);
                  }
                  //Serial.println("|\n");
                }
                //sentry.Snapshot( SNAPSHOT_TO_USB);
                
          break;
        //Serial.print(dataPoint11[0]);

        //Serial.print(",");
        //Serial.print(dataPoint11[1]);
              

      }
  
  
  //int pos=Serial.parseInt();//分析串口数据中整数信息
  //Serial.print("pos value:");
  //Serial.println(pos);//在上一行继续输出

  //int serialData=Serial.read();
  //Serial.println(serialData);

     
 // Serial.println(dataPoint11[0]);
  //Serial.print(",");
 // Serial.print(dataPoint11[1]);



}

}


void manipZeroSetup(AccelStepper stepperX, AccelStepper stepperY, AccelStepper stepperZ, int xEndstopPin, int yEndstopPin, int zEndstopPin, int movementSpeed)
{
     while(digitalRead(xEndstopPin) == LOW || digitalRead(yEndstopPin) == LOW || digitalRead(zEndstopPin) == LOW) {
        
          setMotorToZeroPoint(stepperX, xEndstopPin, -movementSpeed);
          setMotorToZeroPoint(stepperY, yEndstopPin, movementSpeed);
          setMotorToZeroPoint(stepperZ, zEndstopPin, -movementSpeed);
    }
}

void setMotorToZeroPoint(AccelStepper stepper, int endstopPin, int movementSpeed) {
  
   if (digitalRead(endstopPin) == HIGH) {  // 如果按下轴限位开关
    stepper.setCurrentPosition(0);         // 将当前电机位置设置为零
    stepper.stop();                        // 停止电机运转
  }
  else
    stepper.move(movementSpeed);

  stepper.run();
   
}
