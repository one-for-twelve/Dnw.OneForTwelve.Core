# Introduction 

.NET version of the 1-for-12 Game Api.

# Publish a new version

List current tags:

```bash
git tag
```

Tag a new version:

```bash
git tag v0.1.0
```

and then push the tag:

```bash
git push origin v0.1.0
```

Make sure you only tag versions on the main branch. The github actions workflow will create the package and upload it to nuget.