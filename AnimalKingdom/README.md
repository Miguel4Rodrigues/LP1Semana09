# Animal Kingdom

Este projeto demonstra os conceitos de **Herança**, **Polimorfismo** e **Interfaces** em C# através de uma simulação do reino animal.

## Diagrama de Classes (UML)

Abaixo está o diagrama UML que representa as relações entre as classes e interfaces do projeto:

```mermaid
classDiagram
    %% Declaração das Classes e Interfaces
    class Animal {
        <<abstract>>
        +Sound() string
    }

    class Dog {
        +Sound() string
    }

    class Cat {
        +Sound() string
    }

    class Bat {
        +Sound() string
    }

    class Bee {
        +Sound() string
    }

    class IMammal {
        <<interface>>
        +NumberOfNipples int
    }

    class ICanFly {
        <<interface>>
        +NumberOfWings int
    }

    %% Relações de Herança (Setas contínuas com triângulo vazio: <|--)
    Animal <|-- Dog
    Animal <|-- Cat
    Animal <|-- Bat
    Animal <|-- Bee

    %% Relações de Implementação de Interfaces (Setas tracejadas: ..|>)
    IMammal <|.. Dog
    IMammal <|.. Cat
    IMammal <|.. Bat
    ICanFly <|.. Bat
    ICanFly <|.. Bee