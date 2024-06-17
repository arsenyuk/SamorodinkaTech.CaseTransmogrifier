# About

CaseTransmogrifier is designed to give the string identifier a name according to the corresponding naming convention.

## Getting started

The component supports 4 types of identifier formats: camel case, pascal case, snake case, kebab case.


## Usage

```
dotnet add package SamorodinkaTech.CaseTransmogrifier
```

### Converting an identifier to camel case
```
using SamorodinkaTech.CaseTransmogrifier;

...

var token = "payment_limit";

Console.Write(token.CamelCase());
```
Output result
```
paymentLimit
```

### Converting an identifier to pascal case
```
using SamorodinkaTech.CaseTransmogrifier;

...

var token = "payment_limit";

Console.Write(token.PascalCase());
```
Output result
```
PaymentLimit
```

### Converting an identifier to snake case
```
using SamorodinkaTech.CaseTransmogrifier;

...

var token = "PaymentLimit";

Console.Write(token.SnakeCase());
```
Output result
```
payment_limit
```

### Converting an identifier to kebab case
```
using SamorodinkaTech.CaseTransmogrifier;

...

var token = "PaymentLimit";

Console.Write(token.KebabCase());
```
Output result
```
payment-limit
```

## Practical example

For a known json data format, calculate the names of classes and properties in the required in-program style.

## License

This library is licensed under the [MIT License](LICENSE).