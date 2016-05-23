Api for Mi9 test
Author: Glenn Zheng
Date: 24 May 2016

Technologies:
WebApi 2.2
.Net 4.5.2
visual studio 2013 (can run in visual studio 2015)
Packages: Autofac(for dependency injection)
Unit testing: MSTest, Moq

Backend architechture:

 WebApi <- Service layer / Dto

Be aware that I keep all dlls and packages upload to github. This save time by avoiding reinstallation of nuget packages. It makes reviewer easier to review the test.

Therefore, .ignore file is not provided the full filter of the nuget packages.