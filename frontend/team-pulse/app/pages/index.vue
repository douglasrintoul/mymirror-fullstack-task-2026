<script setup lang="ts">
import type { PulseFormData, SubmitPulseResponse } from '~/types/pulse-form';

useHead({ title: 'Submit Pulse - Team Pulse' });
const config = useRuntimeConfig();
const loading = ref(false);
const formSubmissionSuccessful = ref(false);
const error = ref('');

async function handleSubmit(data: PulseFormData) {
	loading.value = true;
	formSubmissionSuccessful.value = false;
	error.value = '';

	try {
		const response = await $fetch<SubmitPulseResponse>('/api/pulse', {
			method: 'POST',
			baseURL: config.public.apiBaseUrl,
			body: {
				score: data.score,
				comment: data.comment,
				categoryId: data.categoryId,
			},
		});

		if (response.success) {
			formSubmissionSuccessful.value = true;
		}
		else {
			error.value = 'Error: Failed to submit pulse';
		}
	}
	catch (e: unknown) {
		error.value = e instanceof Error ? e.message : 'Something went wrong.';
	}
	finally {
		loading.value = false;
	}
}
</script>

<template>
	<PulseCard>
		<h2>How Are You Feeling Today?</h2>
		<SubmitPulseForm
			:loading="loading"
			:form-submission-successful="formSubmissionSuccessful"
			:error="error"
			@submit="handleSubmit"
		/>
	</PulseCard>
</template>
