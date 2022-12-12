use "std"

new = ldef (func) {
	print(func("Hello, world!"))
}

main = ldef(str) {
	return str
}

new(main)

stop()
