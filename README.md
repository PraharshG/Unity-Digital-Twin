This project contains a digital twin of a human fall detection system. A MPU6050 sensor connected to an arduino or an ESP32 gives the orientation of a physical object. 
The motion and orrientation of the physical object is mirrored into the digital twin in unity.
The bridge.py file acts as a mediator between the incoming serial values and unity. Unity on mac currently does not offer support to open serial ports
The getOrientation.ino file publishes orientation values continuosly into the serial port.
