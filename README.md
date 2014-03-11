#anagrams-builder
Anagrams Builder based on a dictionary in C#


#Question
Write a program to compute all anagrams of a word

Example:

- **dog** - is a word
- **god** - is a word
- **odg** - is not a word

> signature('dog') === signature('god')  <- dog and god are words
> 
> signature('dog') !== signature('odg')