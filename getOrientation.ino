#include <Wire.h>
#include <MPU6050.h>

MPU6050 mpu;
float roll, pitch, yaw;

void setup() {
  Serial.begin(115200);
  Wire.begin();
  
  // Initialize the MPU6050
  mpu.initialize();
  if (!mpu.testConnection()) {
    Serial.println("MPU6050 connection failed");
    while (1);
  }
}

void loop() {
  // Read the accelerometer and gyroscope data
  int16_t ax, ay, az, gx, gy, gz;
  mpu.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);
  
  // Calculate orientation angles
  roll = atan2(ay, az) * 180 / PI;
  pitch = atan2(-ax, sqrt(ay * ay + az * az)) * 180 / PI;
  yaw = atan2(gy, gx) * 180 / PI;  // Simplified yaw calculation; requires more complex math for better accuracy

  // Send the angles to Unity over serial
  Serial.print("ROLL:");
  Serial.print(roll);
  Serial.print(",PITCH:");
  Serial.print(pitch);
  Serial.print(",YAW:");
  Serial.println(yaw);

  delay(100);  // Adjust the delay as needed
}
