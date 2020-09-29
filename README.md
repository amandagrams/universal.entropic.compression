<h1 align="center">Welcome to Universal Entropic Compression 👋</h1>
<p>
  <img alt="Version" src="https://img.shields.io/badge/version-1.0.0-blue.svg?cacheSeconds=2592000" />
  <a href="https://tldrlegal.com/license/mit-license" target="_blank">
    <img alt="License: MIT" src="https://img.shields.io/badge/License-MIT-yellow.svg" />
  </a>
</p>

> Este projeto tem como objetivo elaborar uma solução computacional que codifique(compacte) e decodifique(descompacte) arquivos, utilizando os seguintes codificadores:
   *	Golomb
   *	Elias Gamma
   *	Fibonacci
   *	Unary
   *	Delta
>A ideia é desenvolver uma solução de compactação utilizando abordagens de codificação a nível de símbolo, mas que também trate a ocorrência da repetição simples de símbolos ao longo do texto.
O trabalho também tem o objetivo de implementar o CRC-8 para os dois primeiros bytes de um arquivo já codificado e adicionar 7bits de paridade Hamming a cada 4 bits lidos.

## Abordagem / Funcionamento
>Cada codificador possui uma classe de serviço que é instanciada ao selecionar o codificador no menu, cada classe implementa um método de encode e decode, que são chamados quando selecionados no menu.
Na camada de serviço estão as classes responsáveis pelo cálculo do CRC-8 e também a classe responsável pelo cálculo dos 7bits Hamming de paridade.
Há uma opção no menu para aplicar o CRC-8 e Hamming aos arquivos já codificados. 
Também foi implementado o cálculo da entropia para os arquivos Alice29.txt e sum.

![image](https://user-images.githubusercontent.com/4412478/94617651-54666c00-0280-11eb-967b-348ccf9186a4.png)

## Limitações

### Elias Gamma :calendar:
>Limitação na hora de codificar/decodificar o arquivo sum
### Golomb :calendar:
>Limitação na hora de decodificar o arquivo sum.
### Fibonacci :calendar:
>Limitação na hora de decodificar o arquivo sum.
### CRC-8 e Hamming :calendar:
>Foi implementada a decodificação, mas não foi aplicada aos arquivos ainda.

## Pré-requisitos do Projeto :white_check_mark:

*	Visual Studio
*	C# 8

## Setup inicial :hammer:

>git clone https://github.com/amandagrams/universal.entropic.compression.git

## Executar :heavy_check_mark:
>Abrir o visual studio universalentropiccompression.sln e clique em universal.entropic.compression 

## Compactar Arquivo :pushpin:

![image](https://user-images.githubusercontent.com/4412478/94617852-a7402380-0280-11eb-9401-c7ae937723c2.png)

![image](https://user-images.githubusercontent.com/4412478/94617918-c048d480-0280-11eb-8177-75d0b27ef99e.png)
![image](https://user-images.githubusercontent.com/4412478/94617944-c8087900-0280-11eb-9748-aeb9456a72a0.png)

## Descompactar Arquivo :pushpin:
![image](https://user-images.githubusercontent.com/4412478/94618005-df476680-0280-11eb-8133-c7919c9ade39.png)

![image](https://user-images.githubusercontent.com/4412478/94618028-e7070b00-0280-11eb-836e-62102c52da48.png)

## Aplicar CRC-8 e Hamming :pushpin:

![image](https://user-images.githubusercontent.com/4412478/94618065-f38b6380-0280-11eb-9551-adaa20da5b04.png)

![image](https://user-images.githubusercontent.com/4412478/94618082-f9814480-0280-11eb-9f31-efd08d001765.png)

## Cálculo de Entropia :pushpin:

![image](https://user-images.githubusercontent.com/4412478/94618117-04d47000-0281-11eb-8462-0d4cf1470ad6.png)


## Author

:ok_woman: **Amanda Grams**

* Github: [@amandagrams](https://github.com/amandagrams)
* LinkedIn: [@https:\/\/www.linkedin.com\/in\/amanda-grams-jabroski-8200a937\/](https://linkedin.com/in/https:\/\/www.linkedin.com\/in\/amanda-grams-jabroski-8200a937\/)

## Show your support

Give a ⭐️ if this project helped you!

## 📝 License

Copyright © 2020 [Amanda Grams](https://github.com/amandagrams).<br />
This project is [MIT](https://tldrlegal.com/license/mit-license) licensed.

