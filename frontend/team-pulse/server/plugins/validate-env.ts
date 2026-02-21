export default defineNitroPlugin(() => {
	const apiBaseUrl = process.env.NUXT_PUBLIC_API_BASE_URL;
	if (!apiBaseUrl) {
		throw new Error('NUXT_PUBLIC_API_BASE_URL environment variable is required');
	}
});
