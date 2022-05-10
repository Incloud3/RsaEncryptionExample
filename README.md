# RsaEncryptionExample
Basic console application which uses asymmetric encryption algorithm with two generated keys

 ## Table of contents
* [About app](#about-app)
* [Languages and tools](#languages-and-tools)
* [What I learned during this project](#what-i-learned-during-this-project)


## About app
It's a simple app that was created for studies. Uses System.Security.Cryptography library which has most of needed classes <br>
It begins with creating a RSA cryptoSerivceProvider and generation of public and private key while whole app uses three methods for its core. <br>
- GetKeyString which is a method that turns generated key into a string which can be shown (just for educational purpouses)
- Encrypt which is responsible for encryption with presented public key
- Decryption responsible for decryption with private key <br>

Example output which presents both keys and data <br>
![RsaEncryptionExample](https://user-images.githubusercontent.com/103940999/167715866-bedfc400-37b7-4053-b794-8e920abba8d2.png)


## Languages and tools
<img align="left" alt="Visual Studio" width="36px" src="https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/Visual_Studio_Icon_2019.svg/2060px-Visual_Studio_Icon_2019.svg.png" />
<img align="left" alt="CSharp" width="36px" src="https://cdn.worldvectorlogo.com/logos/c--4.svg" style="padding-right:10px;" />
 
<br>

## What I learned during this project
- usage of additional libraries
- basic encryption algorithm for security
- try blocks
