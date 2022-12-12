use "std"

fnum = to_int(input("Enter first number: "))
snum = to_int(input("Enter second number: "))
op = input("Enter operation (+, -, /, *): ")
var result

switch as_var("op") {
	case "+" {
		result = fnum + snum
	}

	case "-" {
		result = fnum - snum
	}

	case "*" {
		result = fnum * snum
	}

	case "/" {
		result = fnum / snum
	}
}

if (op != "+" && op != "-" && op != "*" && op != "/") {
	throw_new_exception("Invalid operation!")
}

print(result)
stop()
