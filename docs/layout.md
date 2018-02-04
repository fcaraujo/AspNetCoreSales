```
$/
  config/
  dist/
  build/
  docs/
  lib/
  packages/
  samples/
  src/
  tests/
  requests/
  .editorconfig
  .gitignore
  .gitattributes
  build.cmd
  build.sh
  LICENSE
  NuGet.Config
  README.md
  {solution}.sln
```


- `src` - Main projects (the product code)
- `tests` - Test projects
- `config` - Custom configuration files
- `docs` - Documentation stuff, markdown files, help files etc.
- `samples` (optional) - Sample projects
- `lib` - Things that can **NEVER** exist in a nuget package
- `dist` - Build outputs go here. Doing a build.cmd/build.sh generates dist here (nupkgs, dlls, pdbs, etc.)
- `packages` - NuGet packages
- `build` - Build customizations (custom msbuild files/psake/fake/albacore/etc) scripts
- `requests` - REST Client requests
- `build.cmd` - Bootstrap the build for windows
- `build.sh` - Bootstrap the build for *nix
- `global.json` - ASP.NET vNext only

## .gitignore
```
[Oo]bj/
[Bb]in/
.nuget/
_ReSharper.*
packages/
dist/
*.user
*.suo
*.userprefs
*DS_Store
*.sln.ide
```

There's probably more things that go in the ignore file.