use "std"
use "socket"

ip_addr_fam = socket_ip_create("0.0.0.0", 8888)
using (socket = new_socket(ADDR_FAMILY_INTNET, SOCKSTREAM, TCP_PROTOCOL)) {
	socket_bind(socket, ip_addr_fam)
	socket_listen(socket, 1000)
	client = socket_accept(socket)
	print(socket_get_socket(client))
}

stop()
