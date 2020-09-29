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

## Limitações

### Elias Gamma
>Limitação na hora de codificar/decodificar o arquivo sum
### Golomb
>Limitação na hora de decodificar o arquivo sum.
### Fibonacci
>Limitação na hora de decodificar o arquivo sum.
### CRC-8 e Hamming
>Foi implementada a decodificação, mas não foi aplicada aos arquivos ainda.

## Pré-requisitos do Projeto

*	Visual Studio
*	C# 8

## Setup inicial

>git clone https://github.com/amandagrams/universal.entropic.compression.git

## Executar
>Abrir o visual studio universalentropiccompression.sln e clique em universal.entropic.compression 

## Author

👤 **Amanda Grams**

* Website: https://www.linkedin.com/in/amanda-grams-jabroski-8200a937/
* Github: [@amandagrams](https://github.com/amandagrams)
* LinkedIn: [@https:\/\/www.linkedin.com\/in\/amanda-grams-jabroski-8200a937\/](https://linkedin.com/in/https:\/\/www.linkedin.com\/in\/amanda-grams-jabroski-8200a937\/)

## Show your support

Give a ⭐️ if this project helped you!

## 📝 License

Copyright © 2020 [Amanda Grams](https://github.com/amandagrams).<br />
This project is [MIT](https://tldrlegal.com/license/mit-license) licensed.

***
_This README was generated with ❤️ by [readme-md-generator](https://github.com/kefranabg/readme-md-generator)_
