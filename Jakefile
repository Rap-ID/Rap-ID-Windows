desc('Gather the DEBUG compiled files.');
task('debug', function () {
	jake.mkdirP('Rap-ID/debug');
	jake.exec([
		'cp -R Auth/bin/Debug/* Rap-ID/debug/',
		'cp -R Configure/bin/Debug/* Rap-ID/debug/',
		'cp -R Installer/bin/Debug/* Rap-ID/debug/',
		'cp -R URLSchemeHandler/bin/Debug/* Rap-ID/debug/',
		'cp -R Library/bin/Debug/* Rap-ID/debug/'
	]);
});
desc('Gather the RELEASE compiled files.');
task('release', function () {
	jake.mkdirP('Rap-ID/release');
	jake.exec([
		'cp -R Auth/bin/Release/* Rap-ID/release/',
		'cp -R Configure/bin/Release/* Rap-ID/release/',
		'cp -R Installer/bin/Release/* Rap-ID/release/',
		'cp -R URLSchemeHandler/bin/Release/* Rap-ID/release/',
		'cp -R Library/bin/Release/* Rap-ID/release/'
	]);
});
desc('Clean up the directory.');
task('clean', function () {
	jake.rmRf('Rap-ID');
});