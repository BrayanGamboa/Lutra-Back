namespace Lutra.Application.Shared.Ports
{
    public interface ICacheServices
    {
        /// <summary>
        /// Obtiene el valor en caché por la clave.
        /// </summary>
        /// <returns>null (en caso de que no se tengan valores o ya expiró), o la propiedad</returns>
        Task<T?> GetAsync<T> (string key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Guarda un valor en el caché por el tiempo de expiración determinado.
        /// </summary>
        Task SetAsync<T>(string key, T value, TimeSpan timeExpiration, CancellationToken cancellationToken = default);

        /// <summary>
        /// Elimina la clave especificada.
        /// </summary>
        Task RemoveAsync<T>(string key, CancellationToken cancellationToken = default);
    }

}
