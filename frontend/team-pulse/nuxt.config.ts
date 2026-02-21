// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2025-07-15',
  devtools: { enabled: true },

  devServer: {
    port: 3000,
  },

  routeRules: {
    // Note: we route API requests to the dotnet API, which runs on port 5295. If we need to facilitate
    // M2M authentication, we could set up an intermediary API through Nuxt to handle authentication
    '/api/**': {
      proxy: 'http://localhost:5295/api/**'
    }
  },

  css: ["@picocss/pico"],

  modules: ['@nuxt/eslint'],
  
  eslint: {
    config: {
      stylistic: {
        semi: true,
        quotes: 'single',
        commaDangle: 'always-multiline',
        indent: 'tab'
      }
    }
  }
})