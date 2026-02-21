<template>
	<span class="loading-spinner" />
</template>

<style scoped>
.loading-spinner {
  display: inline-block;
  width: 1.5em;
  height: 1.5em;
  border: 0.2em solid color-mix(in srgb, var(--hero-blue) 30%, transparent);
  border-top-color: var(--hero-blue);
  border-radius: 50%;
  animation: spin 0.8s linear infinite;
}

@keyframes spin {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>
