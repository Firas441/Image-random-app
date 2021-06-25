# Weenove-application
<h1>Pré-requis</h1>
Le package NuGet Newtonsoft.Json doit être installé dans VS afin de convertir la réponse JSON de la requête http en objet RandomImageJson.
<h1>API Unsplash</h1>
Pour récupérer des images depuis l'API Unsplash un compte développeur a été créé sur le siteweb de l'API afin d'avoir une clé d'accés qui permet d'utiliser la méthode HTTP GET correctement.
<h1>Architecture</h1>
Application est basée sur le pricipe DIP(Dependency Inversion Principle)
<ul>
<li>L'abstraction de cet exercice est d'afficher une image quelque soit depuis l'ordinateur ou depuis le service web Unsplash.</li>
<li>La classe DisplayImage est considérée comme étant un module de haut niveau qui dépend de l'abstaraction de l'exercice representée par l'interface IDisplayImageOperaion, pour se faire la technique DI(Dependency Injection) est utilisée via l'injection de notre interface dans le constructeur de la classe DisplayImage.</li>
<li>Les classes DisplayApiImagesOperation et DisplayLocalImagesOperation sont considérées comme étant des modules de bas niveau qui dépendent aussi de l'abstracion d'afficher une image, pour se faire elles implémentent l'interface IDisplayImageOperaion et donc servent à être utilisé par l'objet DisplayImage en les passants comme paramétre de son constructeur.</li>
<li>Pour ajouter une nouvelle opération, qui se sert de la caméra pour prendre une image par exemple, on n'a pas besoin de modifier la classe DisplayImage mais plutôt on doit créer un nouveau module de bas niveau, cela veut dire une nouvelle classe DisplayCameraImageOperation qui implémente l'interface IDisplayImageOperation, ensuite on l'utilise pour créer notre objet DisplayImage.</li>
</ul>
