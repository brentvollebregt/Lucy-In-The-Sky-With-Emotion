print ("Getting Values...")
f = open("SentiWords_1.0.txt")
values_per_word = {}
for line in f:
    if line.startswith("#"):
        continue
    # Find a way to deal with dupes or find out if words aer a,n,v and then we can take the individual values
    # Will need to find a natual langage toolkit to do this thoguh
    # if line.split("#")[0] in values_per_word:
    #     print ("Already in", line.split("#")[0])

    values_per_word[line.split("#")[0]] = float(line.split("\t")[1].replace("\n", ""))


print ("Values Stored")

#input_string = input("Input: ")
input_string = """

It might seem crazy what I'm about to say
Sunshine she's here, you can take a break
I'm a hot air balloon that could go to space
With the air, like I don't care, baby, by the way

Uh

Because I'm happy
Clap along if you feel like a room without a roof
Because I'm happy
Clap along if you feel like happiness is the truth
Because I'm happy
Clap along if you know what happiness is to you
Because I'm happy
Clap along if you feel like that's what you wanna do

[Verse 2:]
Here come bad news talking this and that, yeah,
Well, give me all you got, and don't hold it back, yeah,
Well, I should probably warn you I'll be just fine, yeah,
No offense to you, don't waste your time
Here's why

Hey
Go
Uh

Bring me down
Can't nothing
Bring me down
My level's too high
Bring me down
Can't nothing
Bring me down
I said (let me tell you now)
Bring me down
Can't nothing
Bring me down
My level's too high
Bring me down
Can't nothing
Bring me down
I said

Hey
Go
Uh

Bring me down... can't nothing...
Bring me down... my level's too high...
Bring me down... can't nothing...
Bring me down, I said (let me tell you now)

Hey
C'mon

"""

for ch in ['!', '"', '#', '$', '%', '&', "'", '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '', ']', '^', '_', '`', '{', '|', '}', '~', '\n', '\t']:
    if ch in input_string:
        input_string.replace(ch, "")

tokens = input_string.split(" ")
total = 0
average = []
for token in tokens:
    if token in values_per_word:
        total += values_per_word[token]
        average.append(values_per_word[token])
        print (token, "\t", values_per_word[token])

print ("Total: ", total)
print ("Average: ", sum(average) / len(average))
