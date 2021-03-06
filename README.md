Требуется разработать систему, отслеживающую состояние коммутаторов в сети.
В БД имеется таблица коммутаторов switch(ID, название), название уникально, а также таблица status(PK, ID_коммутатора, дата_время, действие), где:
- PK – первичный ключ;
- ID_коммутатора – внешний ключ на таблицу коммутаторов;
-дата_время – момент поступление сигнала о смене статуса коммутатора;
- действие: +1, если коммутатор «поднялся» в момент «дата_время» (перешёл в состояние UP), -1 – если «упал» (перешёл в состояние DOWN).

Необходимо написать скрипт создания указанных таблиц и первичного наполнения их данными
(не менее 100 коммутаторов, не менее 500 записей о статусе). Для всех коммутаторов,
находящихся в таблице switch, в скрипте нужно сначала создать записи с действием +1 в таблице
status, после чего корректно ввести данные смены статуса.
В пользовательском интерфейсе (веб-страница)  пользователь должен иметь возможность
выбрать коммутатор (текстовое окно – автокомплит), указать дату и время падения (поднятия),
отправить запрос на внесение информации.
При записи данных в БД модель проверяет корректность (не должно быть подряд для одного
коммутатора двух «падений» или «поднятий»).

Нужно создать страницы отчёта:

1. На указанный пользователем момент времени показать список всех коммутаторов в состоянии UP, DOWN;

2. Для выбранного коммутатора вычислить суммарное время простоя (нахождения в статусе DOWN) за указанный промежуток времени (например: с 01.10.2014 по 31.10.2014);

3. На указанном промежутке времени определить все коммутаторы в режиме flickering (частая смена UP-DOWN). Считать, что коммутатор в этом режиме, если есть 10-
секундный промежуток времени, в течение которого статус изменился не менее 10 раз.
