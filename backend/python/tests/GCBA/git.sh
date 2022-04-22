# Inicializo el branch 
git init

git add .
git commit -m "added new file"
git push -u origin master

# Se quiere revertir la última funcionalidad pusheada

git checkout dev

git add .
git commit -m "added change"
git push -u origin dev

git revert a6451d1

git add .
git commit -m "revert change"
git push -u origin dev

# Se quiere hacer un deploy en producción de la versión 
# que llamaremos v1.2.0, qué pasos seguiría?
# Las soluciones pueden ser en palabras o con comandos GIT.

git checkout dev

git add .
git commit -m "v1.2.0"
git push -u origin dev

# Modifique el mismo archivo que el branch master (agregando nuevas lineas)
# Abro pull request en Github
# Master - Dev (son automaticamente merged)
# El branch dev no tiene conflictos con el branch master
# Apruebo Pull Request
