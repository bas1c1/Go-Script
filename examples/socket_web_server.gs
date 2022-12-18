use "socket"
use "std"

ip = socket_ip_create("127.0.0.1", 8888)

strlen = ldef (str) {
	var n
	foreach str to "i" {
		n++
	}
	return n
}

using (sock = new_socket(ADDR_FAMILY_INTNET, SOCKSTREAM, TCP_PROTOCOL)) {
	socket_bind(sock, ip)
	socket_listen(sock, 10000000)
	while (true) {
		user = socket_accept(sock)
		print(socket_recieve(user))

		response_body = "<h1>Hello, world!</h1>"

		response = "HTTP/1.1 200 OK\r\nVersion: HTTP/1.1\r\nContent-Type: text/html; charset=utf-8\r\nContent-Length:" +
		strlen(response_body) + "\r\n\r\n" + response_body

		socket_send(user, response)

		socket_close(user)
	}
}
