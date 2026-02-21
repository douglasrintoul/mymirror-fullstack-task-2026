// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({

	modules: ['@nuxt/eslint', '@nuxt/icon'],
	devtools: { enabled: true },

	css: ['@picocss/pico'],

	runtimeConfig: {
		public: {
			apiBaseUrl: '',
		},
	},

	devServer: {
		port: 3000,
	},
	compatibilityDate: '2025-07-15',

	eslint: {
		config: {
			stylistic: {
				semi: true,
				quotes: 'single',
				commaDangle: 'always-multiline',
				indent: 'tab',
			},
		},
	},
});
