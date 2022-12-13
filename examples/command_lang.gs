use "std"
use "files"
use "winapi"

variables = new_dictionary()
words = new_arr()

main = ldef () {
	file = read(input("Enter file name: "))
	clear()
	words = split(file, ";")

	for i = 0; i < length("words"); i++ {
		switch words[i] {
			case "input" {
				i++
				add("variables", words[i], input())
			}
			case "eq" {
				i += 2
				add("variables", words[i-1], words[i])
			}
			case "print" {
				i++
				print(get_by_key("variables", words[i]))
			}
			case "stop" {
				stop()
				exit()
			}
			
		}
	}
}

main()
