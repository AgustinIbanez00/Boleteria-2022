export interface webResult {
  result: object;
  success: boolean;
  message: string;
  error_messages: Map<string, string[]>;
  error_code: number;
  error: string;
}
