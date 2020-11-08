rm -rf /d/MakeGroups/

rm -rf ./out/

dotnet publish -c Release -o out

cp -r out/ /d/MakeGroups

