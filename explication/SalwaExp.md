### L'énigme des statues :
-Ecrire le script qui verifie que les torches ont été allumées dans l'ordre pour résoudre l'énigme
-implémenter une méthode pour allumer les torches : soit avec le Raytracing, soit avec un miroir + fasceau lumineux (solution proposée par les anciens)

### Highlighter :


### allumer les torches :

dans le gameobject Torches, on a 4 torches dont chacune dispose de deux fils : "torch particle" et "Point light"
"torch particle" : est un élément qu'on va activer au moment ou on s'approche à la torche pour l'allumer, il permet d'afficher un effet de feu grâce au component Particle System

"Point light" : est un élément qui va permettre grâce a son collider l'interaction avec les torches 
