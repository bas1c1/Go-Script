use "socket"
use "std"

using(socket = new_socket(ADDR_FAMILY_INTNET, SOCKSTREAM, TCP_PROTOCOL)) {
	socket_connect(socket, socket_ip_create("127.0.0.1", 8888))
}

stop()
