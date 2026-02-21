<script setup lang="ts">
import type { PulseFormData } from '~/types/pulse-form';

const loading = ref(false);
const showSuccessMessage = ref(false);
const error = ref('');

function handleSubmit(data: PulseFormData) {
	showSuccessMessage.value = false;
	error.value = '';
	console.log(data);
}
</script>

<template>
	<PulseCard>
		<h2>How Are You Feeling Today?</h2>
		<SubmitPulseForm
			:loading="loading"
			:show-success-message="showSuccessMessage"
			:error="error"
			@submit="handleSubmit"
		/>
	</PulseCard>
</template>
