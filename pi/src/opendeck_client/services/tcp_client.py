import socket
import logging

class TcpClient:
    def __init__(self):
        self.client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

    def connect(self):
        try:
            logging.info(f"Connecting to {HOST}:{PORT}...")
            self.client_socket.connect((HOST, PORT))
            logging.info("Connected successfully!")
        except Exception as e:
            logging.info(f"An error occurred: {e}")

    def send_message(self, message: str):
        try:
            self.client_socket.send(message.encode('utf-8'))
            logging.info("Message Sent")
        except Exception as e:
            logging.info(f"An error occurred: {e}")

    def disconnect(self):
        try:
            self.client_socket.close()
            logging.info("Disconnected")
        except Exception as e:
            logging.info(f"An error occured: {e}")

