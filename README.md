
<div align="center">
<p>
    <img src="Onion.png" width="150" alt="Onion">
</p>

<h1>This is programming language named "Onion"</h1>
</div>

Onion is an interpreted high-level general-purpose programming language. Its design philosophy emphasizes code readability with its use of significant indentation. This language is very comfortable.

<h1 align="center"> How to use Interpreter? </h1>
  
! This language is only for Windows. !

1. Open cmd.exe
2. Go to your directory with Onion.exe (example: cd C:\Users\User\Desktop\Onion)
3. Write: (Example: Onion file_name.file_type)

<h1 align="center"> Examples </h1>

Print function:

```
use "std"

print("Onion is the best!")

stop()

//Output: Onion is the best!
```

Calculator:

```
use "std"

fnum = to_int(input("Enter first number: "))
snum = to_int(input("Enter second number: "))
op = input("Enter operation (+, -, /, *): ")
var result

if (op == "+") {
	result = fnum + snum
}

if (op == "-") {
	result = fnum - snum
}

if (op == "*") {
	result = fnum * snum
}

if (op == "/") {
	result = fnum / snum
}

if (op != "+" && op != "-" && op != "*" && op != "/") {
	throw_new_exception("Invalid operation!")
}

print(result)
stop()
```

One line calculator:

```
use "std" print(eval(input("Enter expression: "))) stop()
```

Simple console game:

```
use "std"
use "random"
use "cs"

player = "*"
yabloko = "@"

visota = 20
shirina_b_sten = 20
shirina_s_sten = 18

player_x = 10
player_y = 9
yabloko_x = randint(1, 19)
yabloko_y = randint(1, 17)

ochki = 0

fps = 0
kadrov = 0

def mainloop() {
    i_input = get_key()

    for i = 0; i <= visota; i++ {
        if i == 0 || i == 20 {
            for j = 0; j <= shirina_b_sten; j++ {
                sout "#"
            }
        }
        else {
            sout "#"
            for c = 0; c <= shirina_s_sten; c++ {
                sout " "
            }
            sout "#"
        }
        sout "\n"
    }


    while (true) {
	sleep(50)

        set_cursor_position(yabloko_x, yabloko_y)
        sout yabloko

	if (player_x == 20 || player_y == 18 || player_x == 0 || player_y == 0) {
            player_x = 10
            player_y = 9
        }

        set_cursor_position(player_x, player_y)
        sout " " + "\b"

        if (yabloko_x == player_x && yabloko_y == player_y) {
            set_cursor_position(yabloko_x, yabloko_y)
            sout " "
            ochki += 1
            yabloko_x = randint(1, 19)
            yabloko_y = randint(1, 17)
        }

        i_input = get_key()

        if i_input == "w" || i_input == "ц" {
            player_y -= 1
        }

        if i_input == "s" || i_input == "ы" {
            player_y += 1
        }

        if i_input == "a" || i_input == "ф" {
            player_x -= 1
        }

        if i_input == "d" || i_input == "в" {
            player_x += 1
        }

        if i_input == "x" || i_input == "ч" {
            exit()
        }

        if (player_x == 20 || player_y == 18 || player_x == 0 || player_y == 0) {
            player_x = 10
            player_y = 9
        }

        set_cursor_position(player_x, player_y)
        sout player

        set_cursor_position(10, 21)
        sout ochki
    }
}

mainloop()
```
