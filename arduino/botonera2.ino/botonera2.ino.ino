int incomingByte = 0;  // for incoming serial data
#define m1 53
#define m2 51
#define m3 49
#define m4 47
int mCount = 0;

#define Xpin A0
#define Ypin A1
int xVal, yVal;


void setup() {

  pinMode(Xpin, INPUT); // A0 x-input
  pinMode(Ypin, INPUT); // A1 y-input
  //pinMode(1, OUTPUT); // blinkers led
  pinMode(2, INPUT_PULLUP);   // wipers
  pinMode(3, INPUT_PULLUP);   // resume cruise
  pinMode(4, INPUT_PULLUP);   // blinkers
  pinMode(5, INPUT_PULLUP);   // parking break
  pinMode(6, INPUT_PULLUP);   // suspension up
  pinMode(7, INPUT_PULLUP);   // suspension down
  pinMode(8, INPUT_PULLUP);   // cruise control
  pinMode(9, INPUT_PULLUP);   // cruise vel +
  pinMode(10, INPUT_PULLUP);  // cruise vel -
  pinMode(11, INPUT_PULLUP);  // low beam lights
  pinMode(12, INPUT_PULLUP);  // HIGH beam lights
  pinMode(13, INPUT_PULLUP);  // joystick click

  pinMode(14, INPUT_PULLUP);  // turn on electronics
  pinMode(15, INPUT_PULLUP);  // turn on engine
  pinMode(16, INPUT_PULLUP);  // retarder +
  pinMode(17, INPUT_PULLUP);  // retarder -


  pinMode(22, INPUT_PULLUP);  // outHorn
  pinMode(23, INPUT_PULLUP);  // left blinker
  pinMode(24, INPUT_PULLUP);  // right blinker
  pinMode(25, INPUT_PULLUP);  //flash
  // pinMode(26, INPUT_PULLUP);  // 
  Serial.begin(9600);

  pinMode(m1, OUTPUT);
  pinMode(m2, OUTPUT);
  pinMode(m3, OUTPUT);
  pinMode(m4, OUTPUT);
}
int blinkerCounter = 0, LED_blinker = A2, pin2 = 0, pin3 = 0, pin4 = 0, pin5 = 0, pin6 = 0, pin7 = 0, pin8 = 0, pin9 = 0, pin10 = 0, pin11 = 0, pin12 = 0, pin13 = 0, pin14 = 0, pin15 = 0, pin16 = 0, pin17 = 0;
int pin22 = 0, pin23 = 0, pin24 = 0, pin25 = 0;

int last_pin2 = 0, last_pin3 = 0, last_pin4 = 0, last_pin5 = 0, last_pin6 = 0, last_pin7 = 0, last_pin8 = 0, last_pin9 = 0, last_pin10 = 0, last_pin11 = 0, last_pin12 = 0, last_pin14 = 0, last_pin15 = 0;
int last_pin22 = 0, last_pin23 = 0, last_pin24 = 0, last_pin25 = 0;

void loop() {
  xVal=analogRead(Xpin);
  yVal=analogRead(Ypin);

  pin2 = !digitalRead(2);
  pin3 = !digitalRead(3);
  pin4 = !digitalRead(4);
  pin5 = !digitalRead(5);
  pin6 = !digitalRead(6);
  pin7 = !digitalRead(7);
  pin8 = !digitalRead(8);
  pin9 = !digitalRead(9);
  pin10 = !digitalRead(10);
  pin11 = !digitalRead(11);
  pin12 = !digitalRead(12);
  pin13 = !digitalRead(13);
  pin14 = !digitalRead(14);
  pin15 = !digitalRead(15);
  pin16 = !digitalRead(16);
  pin17 = !digitalRead(17);
  pin22 = !digitalRead(22);
  pin23 = !digitalRead(23);
  pin24 = !digitalRead(24);
  pin25 = !digitalRead(25);
  // c = !digitalRead(6);
  if (pin2 != last_pin2) Serial.println(pin2 == HIGH ? "truck_wipers" : "");
  // Serial.println(pin2 == HIGH ? "ad" : "");
  if (pin3 != last_pin3) Serial.println(pin3 == HIGH ? "truck_cruiseControlResume" : "");
  if (pin4 != last_pin4) Serial.println(pin4 == HIGH ? "truck_blinkersOn" : "truck_blinkersOff");
  if (pin5 != last_pin5) Serial.println(pin5 == HIGH ? "truck_parkBrakeOn" : "truck_parkBrakeOff");
  // if (pin6) Serial.println("truck_suspensionUp");
  // if (pin7) Serial.println("truck_suspensionDown");
  if (pin6 != last_pin6) Serial.println(pin6 == HIGH ? "truck_suspensionUp_start" : "truck_suspensionUp_end");
  if (pin7 != last_pin7) Serial.println(pin7 == HIGH ? "truck_suspensionDown_start" : "truck_suspensionDown_end");
  if (pin8 != last_pin8) Serial.println(pin8 == HIGH ? "truck_cruiseControlOn" : "");
  if (pin9 != last_pin9) Serial.println(pin9 == HIGH ? "truck_cruiseControlSpeed+" : "");
  if (pin10 != last_pin10) Serial.println(pin10 == HIGH ? "truck_cruiseControlSpeed-" : "");
  if (pin11 != last_pin11) Serial.println(pin11 == HIGH ? "truck_lightsBeamLowOn" : "truck_lightsBeamLowOff");
  if (pin12 != last_pin12) Serial.println(pin12 == HIGH ? "truck_lightsBeamHighOn" : "truck_lightsBeamHighOff");
  if (pin13) Serial.println("camera_firstPerson");
  // if (pin25 != last_pin25) Serial.println(pin25 == HIGH ? "truck_lightsBeamHighToggle" : "");
  if (pin14 != last_pin14) Serial.println(pin14 == HIGH ? "truck_electricOn" : "truck_electricOff");
  if (pin15 != last_pin15) Serial.println(pin15 == HIGH ? "truck_engineOn" : "");
  if (pin16) Serial.println("truck_retarder+");
  if (pin17) Serial.println("truck_retarder-");
  if (pin22 != last_pin22) Serial.println(pin22 == HIGH ? "Horn" : "");
  if (pin23 != last_pin23) Serial.println(pin23 == HIGH ? "truck_blinkerLeftToggle" : "");
  if (pin24 != last_pin24) Serial.println(pin24 == HIGH ? "truck_blinkerRightToggle" : "");
  if (pin25 != last_pin25) Serial.println(pin25 == HIGH ? "truck_flash" : "");

  // counter for blinker
  if (pin4) {
    blinkerCounter = blinkerCounter + 100;
    if (blinkerCounter > 1000) {
      blinkerCounter = 0;
    }
    if (blinkerCounter > 499) {
      analogWrite(LED_blinker, 128);
    } else {
      analogWrite(LED_blinker, 0);
    }
  } else {
    analogWrite(LED_blinker, 0);
  }

  // Serial.print("X = ");
  // Serial.println(xVal);
  // Serial.print("Y = ");
  // Serial.println(yVal);

  if(xVal < 650){
    Serial.println("camera_turnLeft");
  }else if(xVal > 750){
    Serial.println("camera_turnRight");
  }

  if(yVal < 650){
    Serial.println("camera_turnUp");
  }else if(yVal > 750){
    Serial.println("camera_turnDown");
  }

  Serial.println();
  delay(100);  // wait for a milisecond



  last_pin2 = pin2, last_pin3 = pin3, last_pin4 = pin4, last_pin5 = pin5, last_pin6 = pin6, last_pin7 = pin7, last_pin8 = pin8, last_pin9 = pin9, last_pin10 = pin10;
  last_pin11 = pin11, last_pin12 = pin12, last_pin14 = pin14, last_pin15 = pin15, last_pin22 = pin22, last_pin23 = pin23, last_pin24 = pin24, last_pin25 = pin25;
}
