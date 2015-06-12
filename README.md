Rap-ID-Windows
=====

This is an implyment for middle layer of Rap-ID.

Duplication
-----

### Release

When building a new version, the `version/*.*.*` branch will be started. A
pre-release is started on version branch while a final release is started on
the master branch.

The version is named in `major.minor.patch.build`.

### Source Code

We used [BuildTool](https://github.com/coderfox/BuildTool) for version management,
thus if you just want to make a build, you may remove the post-build event. Additionally,
If you want to contribute code, you may find a copy at [BuildTool](https://github.com/coderfox/BuildTool) project
and copy a release to the folder where `Rap-ID.sln` exists.

Contribution
-----

All codes with new features should be committed to `feature/*` branch first and
then you may create a pull request to the most recent version branch.

License
-----

Copyright 2015 Rap-ID Project Team

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
