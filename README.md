# Digital Twin for Human Fall Detection System

This project creates a **digital twin** of a human fall detection system. It mirrors the orientation and motion of a physical object, measured by an **MPU6050 sensor** connected to an Arduino or ESP32, into a **Unity** environment. The system is designed to track and replicate physical movements in real-time, providing a virtual visualization of orientation.

---

## Overview

1. **Physical Object**  
   The physical object is equipped with an MPU6050 sensor connected to an Arduino or ESP32. It continuously publishes orientation values to the serial port using the `getOrientation.ino` script.

2. **Bridge Script**  
   The `bridge.py` script acts as a mediator. It reads the orientation values from the serial port and sends them to Unity via a socket connection.  
   *(Unity on macOS does not natively support serial port communication.)*

3. **Unity Digital Twin**  
   The Unity environment includes a virtual object (e.g., the "Banana Man" model) whose orientation matches the physical object. This behavior is implemented using the `Orientation.cs` file.

---

## Getting Started

### Prerequisites
- **Hardware:** Arduino or ESP32 with an MPU6050 sensor.
- **Software:**  
  - Arduino IDE  
  - Python 3  
  - Unity (macOS or other platforms)

---

## Setup Instructions

### 1. Configure the Physical Object
1. Connect the MPU6050 sensor to the Arduino or ESP32.
2. Upload the `getOrientation.ino` sketch to the microcontroller using the Arduino IDE.
3. Ensure the serial connection is properly configured (default: 9600 baud).

### 2. Set Up the Bridge Script
1. Install Python dependencies:  
   ```bash
   pip install pyserial
   ```
2. Run `bridge.py` to start relaying orientation data:  
   ```bash
   python bridge.py
   ```

### 3. Import the Banana Man Model into Unity
1. Download the Banana Man model from the Unity Asset Store or any 3D model source.
2. In Unity:
   - Go to **Assets > Import Package > Custom Package**.
   - Select and import the Banana Man model package into your Unity project.

### 4. Add the Orientation Script to the Banana Man Object
1. Copy the `Orientation.cs` file into your Unity project's **Assets** folder.
2. In the Unity Editor:
   - Drag and drop the Banana Man model into the Scene view.
   - Select the Banana Man object in the Hierarchy panel.
   - In the Inspector panel, click **Add Component**.
   - Search for `Orientation` and add it to the Banana Man object.
3. Ensure the script is properly linked to receive orientation data from the `bridge.py` socket.

---

## File Descriptions
- **`getOrientation.ino`**  
  Arduino/ESP32 script that calculates and outputs the object's orientation to the serial port.
  
- **`bridge.py`**  
  Python script to bridge serial data to Unity via a socket connection.
  
- **`Orientation.cs`**  
  Unity script to update the virtual object's orientation in real-time.

---

## Usage
1. Start the physical object to stream orientation data.
2. Run the `bridge.py` script to forward data to Unity.
3. Open Unity and play the scene to observe the virtual Banana Man mirroring the physical object's motion.





