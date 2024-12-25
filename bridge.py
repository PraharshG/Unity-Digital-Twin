import serial
import socket

ser = serial.Serial('/dev/cu.usbmodem1101', 115200)
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.bind(('localhost', 65432))
server_socket.listen(1)
print("Waiting for Unity to connect...")

connection, _ = server_socket.accept()
print("Unity connected!")

try:
    while True:
        if ser.in_waiting > 0:
            data = ser.readline().decode('utf-8').strip()
            connection.sendall((data + "\n").encode('utf-8'))
except KeyboardInterrupt:
    pass
finally:
    ser.close()
    connection.close()
    server_socket.close()
