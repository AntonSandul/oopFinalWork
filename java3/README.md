# Решение задачи с семинара

## Задача

* Есть некий класс Worker { name, age, salary }.
* Есть некий документ некоторого типа с единственным методом saveAs() для "сохранения" экземпляра Worker в своём формате.
* Есть некая кнопка Button у которой есть метод click().

Задача заключается в том, чтобы у этой кнопки можно было менять поведение без переписывания логики самого метода click(). Конкретно, чтобы нажатие кнопки вызывало преобразование некоторого
экземпляра Worker в представление выбранного формата данных: XML, Markdown или JSON.

## Описание варианта реализации

### Сущности (entities)

* `class Worker { name, age, salary }` &mdash; работник, которого будем "как бы"-сохранять в разных форматах.

### Абстракции (abstractions)

* `interface Button {	click() }` &mdash; абстракция некоей кнопки, умеющей нажиматься.\
\
То, как она информирует своего "клиента" о своём нажатии &mdash;
не специфицировано!\
\
В качестве варианта реализации оповещения о нажатии, будем использовать приём с созданием непосредственно в клиенте экземпляров анонимного типа, производного от данного интерфейса, таким образом в нём же определяя единственную реализацию метода `click()`, в котором благодаря замыканию будем иметь доступ к non-private членам класса-клиента (в нашем случае клиент &mdash; Документ).\
Это позволит в методе `click()` производной Кнопки вызвать нужный метод конкретной реализации клиента, т.о. имитировав информирование клиента о нажатии.

* `interface Document { saveAs() }` &mdash; абстракция некоего Документа, умеющего сохраняться.\
\
Метод saveAs(), служащий для цели "как бы"-сохранения документа, выводит его содержимое в консоль.\
*Примечание к реализации:* Возможно, было бы логично документу вместо функции сохранения
себя, иметь функцию получения своего строкового представления в своём специфичном формате, а функцию сохранения делегировать диалогу-сохранялке (см. далее). Однако следуем тех.заданию с семинара, где у Документа должен быть метод `saveAs()`.

* `interface Dialog { start() clickButton() }` &mdash; абстракция некоего диалога с пользователем. Аналог диалогового окошка, с функцией сохранения чего-либо.\
В нашем случае конкретная реализация будет: 1) завязана на консоль, и 2) отвечать за "сохранение" документа в формате на выбор пользователя.\
\
Так, метод `start()` служит для запуска диалога с целью спросить что-то у пользователя (т.е. в конкретной реализации будет выяснять формат сохранения).\
Метод `clickButton()` позволяет снаружи "кликнуть" по кнопочке, размещённой в диалоге (т.е. конкретной реализации будет по-смыслу кнопкой "Сохранить").

### Конкретное (concrete)

* `class SaveAsDialog` &mdash; консольная реализация диалога-сохранялки (интерфейса `Dialog`).

Конкретные реализации документов-представлений Worker'а в трёх различных форматах (XML, Markdown и JSON):

* `class XmlDocument`
* `class MdDocument`
* `class JsonDocument`

*Примечание к реализации:* Для сериализации в XML и JSON были использованы библиотеки [XStream](https://x-stream.github.io):
 * [xstream-1.4.19](https://repo1.maven.org/maven2/com/thoughtworks/xstream/xstream/1.4.19/xstream-1.4.19.jar)
 * [jettison-1.2](https://repo1.maven.org/maven2/org/codehaus/jettison/jettison/1.2/jettison-1.2.jar)

 ## Пример работы приложения

![example-xml](https://user-images.githubusercontent.com/109767480/209581688-ecc37b2b-ad12-4f89-94e0-0097e774bd8a.png)

![example-md](https://user-images.githubusercontent.com/109767480/209581690-c3fd9452-a6ca-4397-93ce-68e7e2956759.png)

![example-json](https://user-images.githubusercontent.com/109767480/209581694-b14f8673-08e4-4cfa-a33d-a57913d82646.png)