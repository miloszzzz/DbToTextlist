# StatusDisplay App

StatusDisplay was created for Siemens PLC programmers to speed up making textlists of statuses defined in DB or graph sequence steps. It's especially handy with Proface GP-Pro EX textlists limited to 512 lines.

## How to use



1. Open DB with a lot of defined integer variables with start values or graph sequence instance

![image](https://github.com/miloszzzz/statusDisplay/assets/79056094/581fb117-1095-4aa5-a823-6713c62c1adc)
![image](https://github.com/miloszzzz/statusDisplay/assets/79056094/40e4e66d-d40e-4b43-b9eb-b893a03bedea)

2. Click on expanded mode ![image](https://github.com/miloszzzz/statusDisplay/assets/79056094/28f58eeb-0b17-468c-a9d3-df77a66ffece) on the top of the window
3. Copy all content - Ctrl+A, Ctrl+C  

![image](https://github.com/miloszzzz/statusDisplay/assets/79056094/f70b4564-56b3-430b-8135-00af1c0c2a8a)

4. Paste everything into app

![image](https://github.com/miloszzzz/statusDisplay/assets/79056094/0f21d31e-f339-4ffa-ba32-d74be6bc098f)

5. Copy your textlist and/or SCL code for renumbered textlist

![image](https://github.com/miloszzzz/statusDisplay/assets/79056094/3f1b4403-de88-4f9c-9a81-581d8b8cb5a7)

![image](https://github.com/miloszzzz/statusDisplay/assets/79056094/35d86a66-fdc5-4b1a-bc29-bb342f55e74e)


## Renumber list

When your HMI has textlist limitation or you want your texts use small numbers for some reason select this option. It renumbers your statuses/steps and generates simple SCL code with which you can quickly make FC block for displaying text.

## List with numbers

If you want to paste your textlist in Tia Portal project select this option.

## Variable name format

* Camel case is separated
* Underline is replaced with space
* Numbers are separated from words (except numbers on the begining of the variable name)

## Contibution

Any feedback is welcome.

