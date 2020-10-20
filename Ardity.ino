unsigned long last_time = 0;
boolean queue[4];
String queuetemplast;

void setup() {
  Serial.begin(9600);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
  pinMode(A2, INPUT);
  pinMode(A3, INPUT);
  pinMode(A4, INPUT);
}

void loop() {
  if (millis() > last_time + 100) //anti-debouncing
  {
    int left = analogRead(A0);
    int down = analogRead(A1);
    int up = analogRead(A2);
    int right = analogRead(A3);

    int pot = map(analogRead(A4),0,1023,0,100);
    
    if (left>0){
      digitalWrite(9,HIGH);
      queue[1]=true;}
    else if (left<5){
      digitalWrite(9,LOW);}

    if (down>0){
      digitalWrite(10,HIGH);
      queue[2]=true;}
    else if (down<5){
      digitalWrite(10,LOW);}
    
    if (up>0){
      digitalWrite(11,HIGH);
      queue[3]=true;}
    else if (up<5){
      digitalWrite(11,LOW);}

    if (right>0){
      digitalWrite(12,HIGH);
      queue[4]=true;
      }
    else if (right<5){
      digitalWrite(12,LOW);}

    String queuetemp = String(queue[1])+String(queue[2])+String(queue[3])+String(queue[4])+String(pot);
    if (queuetemp != queuetemplast)
    {Serial.println(queuetemp);}
    queuetemplast=queuetemp;
    
    last_time = millis();
    queue[1]=false;
    queue[2]=false;
    queue[3]=false;
    queue[4]=false;
  }
}
