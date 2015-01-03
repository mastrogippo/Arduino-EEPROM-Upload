/*
    Simple code to upload stuff to an EEPROM
	Released by Mastro Gippo under the WTFPL http://www.wtfpl.net/txt/copying/
*/ 

#include <SPI.h>
#include <spieeprom.h>


SPIEEPROM disk1(1); // parameter is type
                    // type=0: 16-bits address
                    // type=1: 24-bits address
                    // type>1: defaults to type 0
int EECS = 10;    // ee cs
void setup() {
	Serial.begin(115200);
	
	digitalWrite(EECS,HIGH);

	disk1.setup(); // setup disk1

	disk1.start_write();
	disk1.send_address(0); // send address

}

void loop() {

	
}

void serialEvent() {
  while (Serial.available()) {
    SPI.transfer(Serial.read()); // Fetch the received byte value into the variable "ByteReceived"
  }
}
