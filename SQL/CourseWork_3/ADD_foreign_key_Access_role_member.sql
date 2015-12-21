--Добавление вторичных ключей в таблицу Access.role_member

alter table Access.role_member
add
	constraint FK__role_member__role_owner foreign key (role_owner) references Access.role,
	constraint FK__role_member__role_offer foreign key (role_offer) references Access.role
	