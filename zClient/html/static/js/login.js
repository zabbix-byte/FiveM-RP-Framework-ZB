window.addEventListener('message', (event) => {
	if (event.data.type === 'open') {
		doOpen();
	}
});