Feature: AddToCart
  Як користувач performance_glitch_user
  Я хочу увійти в систему та додати товар у кошик

@mytag
Scenario: Успішне додавання товару в кошик
  Given Я знаходжусь на сторінці логіну SauceDemo
  When Я вводжу логін "performance_glitch_user" та пароль "secret_sauce"
  And Я натискаю кнопку Add to cart для першого товару
  Then На іконці кошика має відображатися цифра "1"