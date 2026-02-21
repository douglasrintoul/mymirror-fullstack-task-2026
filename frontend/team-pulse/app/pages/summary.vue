<script setup lang="ts">
import type { TeamPulseSummary } from '~/types/pulse-summary';

const config = useRuntimeConfig();
const { data, status, error } = useFetch<TeamPulseSummary>('/api/pulse/summary', {
	lazy: true,
	baseURL: config.public.apiBaseUrl,
});
</script>

<template>
	<PulseCard>
		<h2>Team Pulse Summary</h2>
		<LoadingSpinner v-if="status === 'pending'" />
		<PulseSummary
			v-else-if="data"
			:summary="data"
		/>
        <p v-else-if="error">Couldn't load the summary. Please try again later.</p>
	</PulseCard>
</template>
