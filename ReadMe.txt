A demo está na scene que diz vumark. 

Para modificar o vumark que te intressa é importares a database e o template no objeto vumark. E meteres a tua license key.

Para adicionares animações é no VumarkHandler dentro do hidden source. Depois no vumark handler alteras o valor size e adicionas
o objeto que queres e o seu id.

O unico script que intressa por agora é o vumark handler.
Nesse Script é importante as funções vumark detected e vumark lost.

Vumark detected vai detetar o id do vumark e vai percorrer o array de vuamrks e ver qual tem esse id e ativar o seu objeto.

O vumark lost irá desativar o objeto quando parar de detetar o vumark.
Essas funções foram feitas por mim.

O resto são private calls da app teste. Pelo os meus testes não são de utilidade mas como isto é uma demo é so para testar.